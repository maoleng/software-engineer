<?php declare(strict_types=1);

namespace App\Enums;

use BenSampo\Enum\Attributes\Description;

final class ProductCategory extends BaseEnum
{

    #[Description('Google')]
    public const GOOGLE = 1;
    #[Description('SamSung')]
    public const SAMSUNG = 2;
    #[Description('Sony')]
    public const SONY = 3;
    #[Description('Nokia')]
    public const NOKIA = 4;
    #[Description('LG')]
    public const LG = 5;
    #[Description('Xiaomi')]
    public const XIAOMI = 6;
    #[Description('Vivo')]
    public const VIVO = 7;
    #[Description('Oppo')]
    public const OPPO = 8;
    #[Description('OnePlus')]
    public const ONEPLUS = 9;
    #[Description('Huawei')]
    public const HUAWEI = 10;

}
